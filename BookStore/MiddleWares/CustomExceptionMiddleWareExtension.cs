namespace BookStore.MiddleWares
{
    public static class CustomExceptionMiddleWareExtension
    {
        public static IApplicationBuilder UsecustomExceptionMiddle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleWare>();

        }
    }
}
