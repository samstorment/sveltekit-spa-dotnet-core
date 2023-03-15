var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// render spa files from client/build directory
builder.Services.AddSpaStaticFiles(config => {
    config.RootPath = "client/build";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// use spa
app.UseSpaStaticFiles();
app.UseSpa(builder => {});

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

















