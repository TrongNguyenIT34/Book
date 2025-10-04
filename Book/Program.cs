var builder = WebApplication.CreateBuilder(args);

// Thêm MVC
builder.Services.AddControllersWithViews();

// Đăng ký Session
builder.Services.AddSession();

// Đăng ký Database cho DI
builder.Services.AddScoped<Book.Models.Database>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// bật session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
