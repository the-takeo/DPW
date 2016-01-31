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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DPW
{
    public static class GetPictures
    {
        static readonly List<string> picExtensions = new List<string>() { ".jpg", ".jpeg", ".gif", ".png", ".bmp" };

        /// <summary>
        /// 指定したURLのWebページに表示されている画像アドレスを取得し、
        /// リストにして返す。
        /// </summary>
        /// <param name="url">Webページのアドレス</param>
        public static List<string> getPicturesUrl(string url,List<string> filter)
        {
            List<string> imageAdresses = new List<string>();

            UnDisplayedBrowser udb = new UnDisplayedBrowser();
            udb.NavigateAndWait(url);

            HtmlDocument doc = udb.Document;

            //Webページに表示されている画像の取得
            foreach (HtmlElement imgElement in doc.GetElementsByTagName("IMG"))
            {
                string imgUrl = imgElement.GetAttribute("src");

                if (picExtensions.Contains(Path.GetExtension(imgUrl)) == false)
                    continue;

                //フィルター式が設定されている場合、除外する
                if (filter != null)
                {
                    bool isFiltered = false;

                    foreach (var item in filter)
                    {
                        if (imgUrl.Contains(item))
                        {
                            isFiltered = true;
                            break;
                        }
                    }

                    if (isFiltered)
                        continue;
                }

                if (imageAdresses.Contains(imgUrl) == false)
                {
                    imageAdresses.Add(imgUrl);
                }
            }

            //サムネイル画像をリンク先画像に差し替え
            foreach (HtmlElement linkElement in doc.GetElementsByTagName("A"))
            {
                string imgUrl = linkElement.GetAttribute("href");
                if (picExtensions.Contains(Path.GetExtension(imgUrl)) == false)
                    continue;

                foreach (HtmlElement imgElement in linkElement.GetElementsByTagName("IMG"))
                {
                    if (imageAdresses.Contains(imgElement.GetAttribute("src")))
                    {
                        imageAdresses.Remove(imgElement.GetAttribute("src"));
                        imageAdresses.Add(imgUrl);
                    }
                }
            }

            return imageAdresses;
        }
    }
}
