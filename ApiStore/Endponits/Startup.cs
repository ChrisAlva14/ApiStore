using ApiStore.Endpoints;

namespace ApiStore.Endponits
{
    public static class Startup
    {
        public static void UseEndpoints(this WebApplication app)
        {
            OrderDetailEndpoints.Add(app);
            ProductEndpoints.Add(app);
        }
    }
}
