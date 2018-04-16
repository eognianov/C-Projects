using Forum.App.Models;
using Forum.App.Services;
using Forum.Data;

namespace Forum.App
{
	using System;

	using Microsoft.Extensions.DependencyInjection;

	using Contracts;
	using Factories;

	public class StartUp
	{
		public static void Main(string[] args)
		{
		    IServiceProvider serviceProvider = ConfigureServices();
		    IMainController menu = serviceProvider.GetService<IMainController>();

			Engine engine = new Engine(menu);
			engine.Run();
		}

		private static IServiceProvider ConfigureServices()
		{
			IServiceCollection services = new ServiceCollection();

		    services.AddSingleton<ICommandFactory, CommandFactory>();
		    services.AddSingleton<ILabelFactory, LabelFactory>();
		    services.AddSingleton<IMenuFactory, MenuFactory>();
		    services.AddSingleton<ITextAreaFactory, TextAreaFactory>();

		    services.AddTransient<IUserService, UserService>();
		    services.AddTransient<IPostService, PostService>();
		    services.AddSingleton<ForumData>();

		    services.AddSingleton<ISession, Session>();
		    services.AddSingleton<IMainController, MenuController>();
		    services.AddSingleton<IForumViewEngine, ForumViewEngine>();

		    IServiceProvider serviceProvider = services.BuildServiceProvider();
		    return serviceProvider;
		}
	}
}
