using DataAccess.Infrastructure.Context;
using DataAccess.Models.Concrete;

#region Create 

//using (AppDbContext db = new AppDbContext())
//{
//Category category = new Category
//{
//    Name = "Şarküteri",
//    Description = "Süt ürünleri bulunur.",
//};

//db.Categories.Add(category);
//if (db.SaveChanges() > 0)
//{
//    Console.WriteLine("Kategory eklendi!");
//}
//else
//{
//    Console.WriteLine("Bir hata oluştu!");
//}


////Toplu Ekleme
//Category category1 = new Category
//{
//    Name = "Teknoloji",
//    Description = "Her türlü teknolojik alet bulunur."
//};

//Category category2 = new Category
//{
//    Name = "Manav",
//    Description = "Her türlü meyve - sebze bulunur"
//};
//Category category3 = new Category
//{
//    Name = "Halı-Kilim-Travel",
//    Description = "Her türlü UFO resimleri bulunur."
//};

//List<Category> categories = new List<Category> { category1, category2, category3 };

//foreach (Category category in categories)
//{
//    db.Categories.Add(category);
//    if (db.SaveChanges() > 0)
//    {
//        Console.WriteLine($"{category.Name} eklendi!");
//    }
//    else
//    {
//        Console.WriteLine($"{category.Name} eklenemedi!");
//    }
//}
//}
#endregion

#region Read
//using (var db = new AppDbContext())
//{
//    //SELECT Id, Name, Description, CreatedDate, Status FROM Categories WHERE Status != 3
//    var categories = db.Categories.Where(x => x.Status != DataAccess.Models.Abstract.Status.Passive)
//                                  .Select(x => new 
//                                  {
//                                      x.Id, 
//                                      x.Name,
//                                      x.Description,
//                                      x.CreatedDate,
//                                      x.Status
//                                  }).ToList();

//	foreach (var category in categories)
//	{
//        Console.WriteLine($"Id: {category.Id}\nName: {category.Name}\nDescription: {category.Description}\nCreated Date: {category.CreatedDate}\nStatus: {category.Status}\n=============");
//    }
//}
#endregion

#region Update
//using (var db = new AppDbContext())
//{
//    var category = db.Categories.FirstOrDefault(x => x.Id == 4);

//    category.Name = "Kasap";
//    category.Description = "Et ve tavuk ürünleri.";
//    category.Status = DataAccess.Models.Abstract.Status.Modified;
//    category.UpdatedDate = DateTime.Now;
//    db.Categories.Update(category);

//    if (db.SaveChanges() > 0)
//    {
//        Console.WriteLine("Kategori güncellendi.");
//    }
//    else
//    {
//        Console.WriteLine("Kategori güncellenemedi!");
//    }
//}
#endregion

#region Delete
using (var db = new AppDbContext())
{
    var category = db.Categories.FirstOrDefault(x => x.Id == 4);
    //Normalde silme işlemi yapılmaz. Pasifize edilir.
    //db.Categories.Remove(category);

    category.DeletedDate = DateTime.Now;
    category.Status = DataAccess.Models.Abstract.Status.Passive;

    db.Categories.Update(category);

    if (db.SaveChanges() > 0)
    {
        Console.WriteLine("Kategori silindi.");
        var categories = db.Categories.Where(x => x.Status != DataAccess.Models.Abstract.Status.Passive).ToList();
        Console.WriteLine();
        Console.WriteLine("Kategoriler: ");
        Console.WriteLine();
        foreach (var kategori in categories)
        {
            Console.WriteLine(kategori.Name);
        }
    }

}


#endregion
