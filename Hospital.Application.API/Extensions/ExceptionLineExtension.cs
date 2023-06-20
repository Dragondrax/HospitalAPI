namespace Hospital.Application.API.Extensions
{
    public static class ExceptionLineExtension
    {
        public static int LineNumber(this Exception e)
        {
            int linenum = 0;
            try
            {
                linenum = Convert.ToInt32(e.StackTrace.Substring(e.StackTrace.LastIndexOf(' ')));
            }
            catch
            {}
            return linenum;
        }
    }
}
