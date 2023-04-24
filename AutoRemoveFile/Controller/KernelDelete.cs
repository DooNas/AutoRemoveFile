using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace AutoRemoveFile.Controller
{
    class KernelDelete
    {
        #region Kernel 호출
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
        #endregion

        int savecount = 0;
        public Boolean IsEmptyFolder(String folder)/* 폴더 안에 파일유무 체크 */
        {
            Boolean res = true;

            if (folder == null && folder.Length == 0)
            {
                throw new Exception(folder + "is invalid");
            }

            WIN32_FIND_DATAW findFileData;
            String searchFiles = folder + @"\*.*";
            IntPtr searchHandle = FindFirstFileW(searchFiles, out findFileData);
            if (searchHandle == INVALID_HANDLE_VALUE)
            {
                throw new Exception("Cannot check folder " + folder);
            }

            do
            {
                if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    //  found a sub folder
                    if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                    {
                        res = false;
                        break;
                    }

                }   //  if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                else
                {
                    //  found a file
                    res = false;
                    break;
                }
            } while (FindNextFileW(searchHandle, out findFileData));

            FindClose(searchHandle);
            return res;
        }   
        public Boolean DeleteFolder(String folder, int LastUpHours)/* 절대경로를 기준으로 LastUpdate값을 넘긴 파일,폴더를 제거 */
        {
            Boolean res = true;
            //  keep non-empty folders to delete later (after we delete everything inside)
            Stack<String> nonEmptyFolder = new Stack<String>();
            String currentFolder = folder;
            do
            {
                Boolean isEmpty = false;
                try
                {
                    isEmpty = IsEmptyFolder(currentFolder);
                }
                catch (Exception ex)
                {
                    //  Something wrong
                    res = false;
                    break;
                }

                if (!isEmpty)
                {
                    nonEmptyFolder.Push(currentFolder);
                    WIN32_FIND_DATAW findFileData;
                    IntPtr searchHandle = FindFirstFileW(currentFolder + @"\*.*", out findFileData);
                    if (searchHandle != INVALID_HANDLE_VALUE)
                    {
                        do
                        {   //nonEmptyFolder의 경로를 기반으로 각 폴더의 서브폴더와 파일을 찾는다.
                            String foundPath = currentFolder + @"\" + findFileData.cFileName;
                            if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                            {
                                //  found a sub folder
                                if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                                {
                                    if (IsEmptyFolder(foundPath))
                                    {   //  found an empty folder, delete it
                                        LogController.LogWrite(foundPath, 4);
                                        if (!(res = RemoveDirectoryW(foundPath)))
                                        {
                                            Int32 error = Marshal.GetLastWin32Error();
                                            break;
                                        }
                                    }
                                    else
                                    {   //  found a non-empty folder
                                        nonEmptyFolder.Push(foundPath);
                                    }
                                }   //  if (findFileData.cFileName != "." && findFileData.cFileName != "..")

                            }   //  if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                            else
                            {// 서브폴더 없음
                                DateTime createdDate = File.GetCreationTime(foundPath);
                                if (DateTime.Now.Subtract(createdDate).TotalHours >= LastUpHours)/* daysOld의 값보다 더 지난 날짜일 경우 */
                                {
                                    LogController.LogWrite(foundPath, 4);
                                    if (!(res = DeleteFileW(foundPath)))/* 삭제 진행 */
                                    {   //삭제 실패 여부 체크
                                        int error = Marshal.GetLastWin32Error(); break;
                                    }
                                }
                                else savecount++;
                            }

                            if (nonEmptyFolder.Count != savecount) currentFolder = nonEmptyFolder.Pop();
                            else currentFolder = null;

                            // Check if the condition is still met
                            if (currentFolder == null || DateTime.Now.Subtract(File.GetCreationTime(foundPath)).TotalHours < LastUpHours) break;

                        } while (FindNextFileW(searchHandle, out findFileData));

                        FindClose(searchHandle);

                    }   //  if (searchHandle != INVALID_HANDLE_VALUE)

                }

                if (nonEmptyFolder.Count > 0)
                {
                    currentFolder = nonEmptyFolder.Pop();
                }
                else
                {
                    currentFolder = null;
                }
            } while (currentFolder != null && res);

            return res;
        }   //  public static Boolean DeleteFolder(String folder)
    }
}