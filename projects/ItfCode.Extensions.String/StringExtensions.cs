namespace ItfCode.Extensions.String
{
    public static class StringExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="pairs"></param>
        /// <returns></returns>
        public static string ReplaceAll(this string source, params (string, string)[] pairs)
        {
            ArgumentNullException.ThrowIfNull(source);

            var modified = source;

            while (pairs.Any(x => modified.Contains(x.Item1)))
            {
                foreach (var pair in pairs)
                {
                    modified = modified.Replace(pair.Item1, pair.Item2);
                }
            }

            return modified;
        }

        /// <summary>
        /// Splits multiline string to array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>Array of lines </returns>
        public static string[] LinesToArray(this string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            return value.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Lines to list.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static List<string> LinesToList(this string value)
        {
            ArgumentNullException.ThrowIfNull(value);

            return new List<string>(value.LinesToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="defaltValue"></param>
        /// <returns></returns>
        public static TEnum? ParseEnum<TEnum>(this string value, bool ignoreCase = true, TEnum defaltValue = default) where TEnum : struct
        {
            if (Enum.TryParse(value, ignoreCase, out TEnum enumValue))
                return enumValue;
            else
                return defaltValue;
        }
    }
}