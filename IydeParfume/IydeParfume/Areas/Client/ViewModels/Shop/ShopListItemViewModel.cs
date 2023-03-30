namespace IydeParfume.Areas.Client.ViewModels.Home
{
    public class ShopListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Size { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MainImgUrl { get; set; }


        

        public ShopListItemViewModel()
        {

        }

        public ShopListItemViewModel(int id, string name, string description, int price, int size, DateTime createdAt, string mainImgUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Size = size;
            CreatedAt = createdAt;
            MainImgUrl = mainImgUrl;
        }
    }
}
