using TestTaskOCS.Extentions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication();
builder.Services.AddRouting();
builder.Services.AddControllers();
builder.Services.AddMvc();
builder.Services.AddApplicationtServices();
builder.AddApplicationContext();
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseAuthentication();
app.MapControllers();
app.UseRouting();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.Run();