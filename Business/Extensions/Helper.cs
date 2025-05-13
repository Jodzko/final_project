

namespace _final_project.BusinessLogic.Extensions
{
    public static class Helper
    {
        public static bool IsNullOrBlank(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }
        public static bool IsNullOrZero(this int value)
        {
            if(value != 0)
            {
                return false;
            }
            return true;
        }
    }
}
