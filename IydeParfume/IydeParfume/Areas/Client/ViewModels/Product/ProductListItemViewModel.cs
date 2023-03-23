namespace IydeParfume.Areas.Client.ViewModels.Home
{
    public class ProductListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MainImgUrl { get; set; }


        

        public ProductListItemViewModel()
        {

        }

        public ProductListItemViewModel(int id, string name, int price, int size, DateTime createdAt, string mainImgUrl)
        {
            Id = id;
            Name = name;
            Price = price;
            Size = size;
            CreatedAt = createdAt;
            MainImgUrl = mainImgUrl;
        }
    }
}
