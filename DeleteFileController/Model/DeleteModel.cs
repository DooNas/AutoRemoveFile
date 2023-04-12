using DeleteFileController.Model.inter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DeleteFileController.Model
{
    internal class DeleteModel : interDelete
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        struct WIN32_FIND_DATAW
        {
            public FileAttributes dwFileAttributes;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
            public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
            public UInt32 nFileSizeHigh;  //  DWORD
            public UInt32 nFileSizeLow;  //  DWORD
            public UInt32 dwReserved0;    //  DWORD
            public UInt32 dwReserved1;  //  DWORD
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public String cFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public String cAlternateFileName;
        };
        static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr FindFirstFileW(String lpFileName, out WIN32_FIND_DATAW lpFindFileData);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Boolean FindNextFileW(IntPtr hFindFile, out WIN32_FIND_DATAW lpFindFileData);
        [DllImport("kernel32.dll")]
        private static extern Boolean FindClose(IntPtr handle);
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern Boolean DeleteFileW(String lpFileName);    //  Deletes an existing file
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern Boolean RemoveDirectoryW(String lpPathName);   //  Deletes an existing empty directory

        public Boolean IsEmptyFolder(string folder)
        {
            Boolean res = true;

            if (folder == null && folder.Length == 0)  throw new Exception(folder + "is invalid");

            WIN32_FIND_DATAW findFileData;
            String searchFiles = folder + @"\*.*";
            IntPtr searchHandle = FindFirstFileW(searchFiles, out findFileData);

            if (searchHandle == INVALID_HANDLE_VALUE)  throw new Exception("Cannot check folder " + folder);

            do
            {
                if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {   //  서브폴더가 있는 경우
                    if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                    {
                        res = false;
                        break;
                    }
                }
                else
                {   //  서브폴더가 없는 경우
                    res = false;
                    break;
                }
            } while (FindNextFileW(searchHandle, out findFileData));
            FindClose(searchHandle);

            return res; 
        }

        public Boolean DeleteFolder(string folder, int daysOld)
        {
            bool res = true;

            // Keep non-empty folders to delete later (after we delete everything inside)
            Stack<string> nonEmptyFolders = new Stack<string>(); //지워야할 디렉토리 경로들
            string currentFolder = folder;  //임의로 정한 상위 경로

            do
            {
                bool isEmpty = false;

                try { isEmpty = IsEmptyFolder(currentFolder); }
                catch (Exception ex)
                {   // Something went wrong
                    res = false;
                    break;
                }

                if (!isEmpty)
                {
                    nonEmptyFolders.Push(currentFolder);
                    WIN32_FIND_DATAW findFileData;
                    IntPtr searchHandle = FindFirstFileW(currentFolder + @"\*.*", out findFileData);

                    if (searchHandle != INVALID_HANDLE_VALUE)
                    {   //디렉토리가 있을 경우
                        do
                        {
                            // 상위 디렉토리를 기준으로 하위의 모든 디렉토리와 파일을 찾아서 제거시작
                            string foundPath = currentFolder + @"\" + findFileData.cFileName;

                            if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                            {   // 서브폴더 있음
                                if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                                {
                                    if (IsEmptyFolder(foundPath))
                                    {   // 서브폴더 안에 내용물이 없음
                                        if (!(res = RemoveDirectoryW(foundPath)))/* 삭제 진행 */
                                        {
                                            int error = Marshal.GetLastWin32Error();
                                            break;
                                        }
                                    }
                                    else nonEmptyFolders.Push(foundPath); //서브폴더 안에 내용물이 있음
                                }
                            }
                            else // if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                            {   // 서브폴더 없음
                                DateTime createdDate = File.GetCreationTime(foundPath);
                                if (DateTime.Now.Subtract(createdDate).TotalDays <= daysOld)/* daysOld의 값보다 더 지난 날짜일 경우 */
                                {
                                    if (!(res = DeleteFileW(foundPath)))/* 삭제 진행 */
                                    {
                                        int error = Marshal.GetLastWin32Error();
                                        break;
                                    }
                                }
                            }
                        } while (FindNextFileW(searchHandle, out findFileData));
                        FindClose(searchHandle);
                    }
                }
                else
                {   //디렉토리가 없을 경우
                    if (!(res = RemoveDirectoryW(currentFolder)))
                    {
                        int error = Marshal.GetLastWin32Error();
                        break;
                    }
                }
                //디렉토리 리스트 체크
                if (nonEmptyFolders.Count > 0) currentFolder = nonEmptyFolders.Pop(); 
                else  currentFolder = null;

            } while (currentFolder != null && res);
            return res;
        }
    }
 }
