namespace DotnetCoding.Core.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static TEnum ToEnum<TEnum>(this string value, bool ignoreCase = true) where TEnum : struct
        {
            if (Enum.TryParse(value, ignoreCase, out TEnum result))
            {
                return result;
            }
            else
            {
                // Handle the case where parsing fails, for now, we return the default value
                return default(TEnum);
            }
        }
    }
}