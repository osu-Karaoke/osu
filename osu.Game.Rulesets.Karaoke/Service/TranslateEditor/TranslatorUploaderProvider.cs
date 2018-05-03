﻿namespace osu.Game.Rulesets.Karaoke.Service.TranslateEditor
{
    public class TranslatorServiceProvider
    {
        /// <summary>
        /// Get translator by providerType
        /// </summary>
        /// <param name="providerType"></param>
        /// <returns></returns>
        public static ITranslateEditor GetTranslatorByProvider(TranslatorUploaderProvider providerType)
        {
            switch (providerType)
            {
                case TranslatorUploaderProvider.Github:
                    return new GithubTranslatorEditor();
                default:
                    return null;
            }
        }
    }

    public enum TranslatorUploaderProvider
    {
        /// <summary>
        /// The github.
        /// </summary>
        Github,
    }
}
