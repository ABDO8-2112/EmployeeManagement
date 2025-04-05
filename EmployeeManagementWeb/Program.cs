using EmployeeManagementWeb.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient<EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7008");
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{    
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
