using Blazored.SessionStorage;
using BlzSinhVien.Client;
using BlzSinhVien.Client.Authentication;
using BlzSinhVien.Client.Service.ChucVuService;
using BlzSinhVien.Client.Service.LopHocService;
using BlzSinhVien.Client.Service.SinhVienService;
using BlzSinhVien.Client.Service.UserService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<ISinhVienService, SinhVienService>();
builder.Services.AddScoped<ILopHocService, LopHocService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChucVuService, ChucVuService>();
await builder.Build().RunAsync();
