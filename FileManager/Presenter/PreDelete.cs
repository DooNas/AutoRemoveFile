using FileManager.Model.@interface;
using FileManager.View.@interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

namespace FileManager.Presenter
{
    internal class PreDelete
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

        readonly InFcMain view;
        readonly InFcDelete model;
        readonly InFcLog log;
        public PreDelete(InFcMain view, InFcDelete model, InFcLog log)
        {
            this.view = view;
            this.model = model;
            this.log = log;
        }

        public Boolean DeleteFolder(String SuperDeletePath, int LastUpHours)
        /* DeleteList의 경로를 기준으로 LastUpdate값을 넘긴 파일,폴더를 제거 */
        {
            int savecount = 0;

            Boolean res = true;
            //  
            Stack<String> nonEmptyFolder = new Stack<String>();
            String currentFolder = SuperDeletePath;
            do
            {
                Boolean isEmpty = false;

                try { isEmpty = IsEmptyFolder(currentFolder); }
                catch (Exception)/* 예외처리 */{ res = false; break; }

                if (!isEmpty)
                {
                    nonEmptyFolder.Push(currentFolder);
                    WIN32_FIND_DATAW findFileData;
                    IntPtr searchHandle = FindFirstFileW(currentFolder + @"\*.*", out findFileData);
                    if (searchHandle != INVALID_HANDLE_VALUE)
                    {
                        do
                        {   
                            String foundPath = currentFolder + @"\" + findFileData.cFileName;
                            if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                            /* 하위 디렉토리가 있을 경우 */
                            {
                                if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                                {
                                    if (IsEmptyFolder(foundPath))
                                    /* 빈 폴더일 경우 삭제처리 */
                                    {
                                        log.LogPrint(foundPath, 4);
                                        if (!(res = RemoveDirectoryW(foundPath))) { Int32 error = Marshal.GetLastWin32Error(); break; }
                                    }
                                    /* 빈 폴더가 아닐 경우 nonEmptyFolder(stack)배열에 해당 폴더 추가 */
                                    else { nonEmptyFolder.Push(foundPath); }
                                }
                            }
                            else
                            /* 하위 디렉토리가 없을 경우 */
                            {
                                DateTime createdDate = File.GetCreationTime(foundPath);
                                if (DateTime.Now.Subtract(createdDate).TotalHours >= LastUpHours)
                                /* 보존기간보다 길게 보관된 경우 */
                                {
                                    log.LogPrint(foundPath, 4);
                                    if (!(res = DeleteFileW(foundPath))) { Int32 error = Marshal.GetLastWin32Error(); break; }
                                }
                                /* 보존기간보다 적게 보관된 경우 */
                                else savecount++;

                            }

                            /* nonEmptyFolder에 보존기간을 충족하는 folder 제거 */
                            if(Directory.GetFiles(foundPath).Length == savecount) 
                            
                            // Check if the condition is still met
                            if (currentFolder == null || DateTime.Now.Subtract(File.GetCreationTime(foundPath)).TotalHours < LastUpHours) break;

                        } while (FindNextFileW(searchHandle, out findFileData));

                        FindClose(searchHandle);

                    }   //  if (searchHandle != INVALID_HANDLE_VALUE)

                }

                if (nonEmptyFolder.Count > 0) currentFolder = nonEmptyFolder.Pop();
                else currentFolder = null;
            } while (currentFolder != null && res);

            return res;
        }

        public bool IsEmptyFolder(string folder)
        /* 폴더 안에 파일유무 체크 */
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

                }
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
    }
}
