using ApiStore.Endpoints;

namespace ApiStore.Endponits
{
    public static class Startup
    {
        public static void UseEndpoints(this WebApplication app)
        {
            UserEndpoints.Add(app);
            OrderDetailEndpoints.Add(app);
            ProductEndpoints.Add(app);
            OrderEndpoints.Add(app);
            CategoryEndpoints.Add(app);

        }
    }
}
