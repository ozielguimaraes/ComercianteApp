namespace Domain.Extensions
{
    public static class NullExtensions
    {
        public static bool IsNull(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            return false;
        }
    }
}