using BlzSinhVien.Server.Authentication;
using BlzSinhVien.Server.Data;
using BlzSinhVien.Server.Service.ChucVuService;
using BlzSinhVien.Server.Service.GiangDuongService;
using BlzSinhVien.Server.Service.GiaoVienService;
using BlzSinhVien.Server.Service.HocKyService;
using BlzSinhVien.Server.Service.ImageService;
using BlzSinhVien.Server.Service.KhoaService;
using BlzSinhVien.Server.Service.LopHocService;
using BlzSinhVien.Server.Service.MonHocChuyenNganhService;
using BlzSinhVien.Server.Service.MonHocKhoaService;
using BlzSinhVien.Server.Service.MonHocService;
using BlzSinhVien.Server.Service.NganhHocService;
using BlzSinhVien.Server.Service.SinhVienService;
using BlzSinhVien.Server.Service.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"));
});

builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChucVuService, ChucVuService>();
builder.Services.AddScoped<IGiaoVienService, GiaoVienService>();
builder.Services.AddScoped<IMonHocService, MonHocService>();
builder.Services.AddScoped<IMonHocKhoaService, MonHocKhoaService>();
builder.Services.AddScoped<IMonHocChuyenNganhService, MonHocChuyenNganhService>();
builder.Services.AddScoped<INganhHocService, NganhHocService>();
builder.Services.AddScoped<IKhoaService, KhoaService>();
builder.Services.AddScoped<IHocKyService, HocKyService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IGiangDuongService, GiangDuongService>();
builder.Services.AddAuthentication(o =>
{
    o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = false;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtAuthenticationManager.JWT_SECURITY_KEY)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
