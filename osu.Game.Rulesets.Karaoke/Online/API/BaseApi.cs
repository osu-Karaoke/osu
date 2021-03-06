﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace osu.Game.Rulesets.Karaoke.Online.API
{
    public abstract class BaseApi
    {
        /// <summary>
        ///     api must has url
        /// </summary>
        protected abstract string Host { get; }

        /// <summary>
        ///     Get api
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected async Task<string> GetStringApi(string path, List<KeyValuePair<string, string>> parameter)
        {
            var client = new WebClient();
            client.Encoding = Encoding.UTF8;

            var parameterString = "";

            foreach (var single in parameter)
            {
                var isFirst = parameter.IndexOf(single) == 0;
                parameterString = parameterString + (isFirst ? "?" : "&") + single.Key + "=" + single.Value;
            }

            var url = Host + path + parameterString;

            var json = await client.DownloadStringTaskAsync(url);

            return json;
        }

        /// <summary>
        ///     Get api
        /// </summary>
        /// <param name="path"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        protected async Task<T> GetObjectApi<T>(string path, List<KeyValuePair<string, string>> parameter)
        {
            var json = await GetStringApi(path, parameter);

            var obj = JsonConvert.DeserializeObject<T>(json);

            return obj;
        }
    }
}
