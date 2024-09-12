namespace ApiStore.DTOs
{
    public class CategoryResponse
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class CategoryRequest
    {
        //public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }
}
