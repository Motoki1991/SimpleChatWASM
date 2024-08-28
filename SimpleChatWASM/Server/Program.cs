using SimpleChatWASM.Shared.Repositories.TestRepositories;
using SimpleChatWASM.Shared.Repositories;
using SimpleChatWASM.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSingleton<IRoomRepository, RoomRepositoryTest>();
//   (provider =>
//{
//    using (var scope = provider.CreateScope())
//    {
//        var context = scope.ServiceProvider.GetRequiredService<SimpleChatContext>();
//        return new RoomRepository(context);        
//    }
//}
//);
builder.Services.AddSingleton<IUserRepository, UserRepositoryTest>();
//    (provider =>
//{
//    using (var scope = provider.CreateScope())
//    {
//        var context = scope.ServiceProvider.GetRequiredService<SimpleChatContext>();
//        //return new UserRepository(context);
//        return new UserRepositoryTest();
//    }
//}
//);
builder.Services.AddSingleton<IMessageRepository, MessageRepositoryTest>();
//    (provider =>
//{
//    using (var scope = provider.CreateScope())
//    {
//        var context = scope.ServiceProvider.GetRequiredService<SimpleChatContext>();
//        //return new MessageRepository(context);
//        return new MessageRepositoryTest();
//    }
//}
//);
builder.Services.AddSingleton<IInformationRepository, InformationRepositoryTest>();
//    (provider =>
//{
//    using (var scope = provider.CreateScope())
//    {
//        var context = scope.ServiceProvider.GetRequiredService<SimpleChatContext>();
//        //return new Informationrepository(context);
//        return new InformationRepositoryTest();
//    }
//}
//);

//’Ç‰Á
builder.Services.AddSignalR();

var app = builder.Build();

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

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

//’Ç‰Á
app.MapHub<ChatHub>("/chathub");

app.Run();
