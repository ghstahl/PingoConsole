﻿using System.Runtime.InteropServices;

namespace Pingo.MEF.Contrib
{
    // https://github.com/danielpalme/ReportGenerator/blob/master/ReportGenerator/Reporting/FileUnblocker.cs
    // I liked it so much I took it.
    /// <summary>
    /// Helper class for unblocking files.
    /// </summary>
    internal static class FileUnblocker
    {
        /// <summary>
        /// Unblocks the given file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><c>true</c> if file was unblocked successfully; otherwise, <c>false</c></returns>
        public static bool Unblock(string fileName)
        {
            return DeleteFile(fileName + ":Zone.Identifier");
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns><c>true</c> if file was deleted successfully; otherwise, <c>false</c></returns>
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);
    }
}
