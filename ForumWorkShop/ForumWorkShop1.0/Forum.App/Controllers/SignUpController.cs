using System;
using Forum.App.Services;
using Forum.App.UserInterface;

namespace Forum.App.Controllers
{
	using Forum.App;
	using Forum.App.Controllers.Contracts;
	using Forum.App.UserInterface.Contracts;

	public class SignUpController : IController, IReadUserInfoController
	{
        private enum Command
        {
            ReadUsername, ReadPassword, SignUp, Back
        }

        public enum SignUpStatus
        {
            Success, DetailsError, UsernameTakenError
        }


		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

	    private string ErrorMessage { get; set; }

	    public string Username { get; set; }
	    public string Password { get; set; }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    SignUpStatus signUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (signUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            this.ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTakenError:
                            this.ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }

                    return MenuState.Error;
                case Command.Back:
                    ResetSignUp();
                    return MenuState.Back;
                default:
                    throw new NotSupportedException();
            }
        }

        public IView GetView(string userName)
        {
            return  new SignUpView(this.ErrorMessage);
        }

	    public void ReadPassword()
	    {
	        Password = ForumViewEngine.ReadRow();
	        ForumViewEngine.HideCursor();
	    }


	    public void ReadUsername()
	    {
	        Username = ForumViewEngine.ReadRow();
	        ForumViewEngine.HideCursor();
	    }

        private void ResetSignUp()
	    {
	        Username = string.Empty;
	        ErrorMessage = string.Empty;
	        Password = string.Empty;
	    }
    }
}
