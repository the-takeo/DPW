/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2016 the-takeo
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DPW
{
    public class Download
    {
        readonly string[] invalidPathStrings = new string[9] { @"\", @"/", @"?", @":", @"|", @"*", @"<", @">", @"""" };

        private int downloadCount = 0;

        public int DownloadCount
        { get { return downloadCount; } }

        WebClient wc = new WebClient();

        public void StartDownload(string pictureAddress, string folder)
        {
            if (folder.EndsWith(@"\") == false)
                folder = folder + @"\";

            wc = new WebClient();

            string downloadingfileName = replaceValidChar(pictureAddress);

            string fileName = folder + downloadingfileName;
            fileName = addNumbering(fileName);

            wc.DownloadFile(new Uri(pictureAddress), fileName);
        }

        private string replaceValidChar(string imageAdresse)
        {
            string downloadingfileName = imageAdresse;

            //禁則文字の置換
            foreach (var InvalidPathChar in Path.GetInvalidPathChars())
            {
                if (imageAdresse.Contains(InvalidPathChar.ToString()))
                    downloadingfileName = imageAdresse.Replace(InvalidPathChar, '_');
            }

            downloadingfileName = Path.GetFileName(downloadingfileName);

            //禁則文字の置換
            foreach (var InvalidPathString in invalidPathStrings)
            {
                if (imageAdresse.Contains(InvalidPathString))
                    downloadingfileName = downloadingfileName.Replace(InvalidPathString, "_");
            }

            return downloadingfileName;
        }

        private string addNumbering(string fileName)
        {
            int count = 1;

            //保存名が既に存在する場合、末尾にナンバリングを行い重複しないようにする
            while (System.IO.File.Exists(fileName))
            {
                string extension = Path.GetExtension(fileName);

                fileName = fileName.Remove(fileName.Length - extension.Length, extension.Length);

                if (count != 1)
                    fileName = fileName.Remove(fileName.Length - count.ToString().Length, count.ToString().Length);

                fileName = fileName + count.ToString() + extension;

                count++;
            }

            return fileName;
        }
    }
}
