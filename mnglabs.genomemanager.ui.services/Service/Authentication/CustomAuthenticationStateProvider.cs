using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;


namespace mnglabs.genomemanager.ui.services.Service
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        public CustomAuthenticationStateProvider()
        {
            this.CurrentUser = this.GetAnonymous();
        }

        private ClaimsPrincipal CurrentUser { get; set; }

        public int LoginAttempts
        {
            get
            {
                var attemptClaim = CurrentUser.Claims.FirstOrDefault(c => c.Type.Equals("LoginAttempts"));
                if (attemptClaim != null)
                {
                    var loginAttempts = 0;
                    int.TryParse(attemptClaim.Value, out loginAttempts);
                    return loginAttempts;
                }
                return 0;
            }
            set
            {
                var claimIdentity = CurrentUser.Identity as ClaimsIdentity;
                var attemptClaim = CurrentUser.Claims.FirstOrDefault(c => c.Type.Equals("LoginAttempts"));
                if (attemptClaim != null)
                {
                    claimIdentity.RemoveClaim(attemptClaim);
                    var claim = new Claim("LoginAttempts", value.ToString());
                    claimIdentity.AddClaim(claim);
                }

            }
        }
        
        private ClaimsPrincipal GetUser(string userName, string role)
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Role, role)
        }, "Authentication type");
            return new ClaimsPrincipal(identity);
        }

        private ClaimsPrincipal GetAnonymous()
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Sid, "0"),
            new Claim(ClaimTypes.Name, "Anonymous"),
            new Claim(ClaimTypes.Role, "Anonymous"),
            new Claim("LoginAttempts", "0")

        }, null); ;
            return new ClaimsPrincipal(identity);
        }
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //var identity = new ClaimsIdentity();
            //var user = new ClaimsPrincipal(identity);

            //return Task.FromResult(new AuthenticationState(user));
            var task = Task.FromResult(new AuthenticationState(this.CurrentUser));
            return task;
        }

        public Task<AuthenticationState> ChangeUser(string username, string role)
        {
            this.CurrentUser = this.GetUser(username, role);
            var task = this.GetAuthenticationStateAsync();
            this.NotifyAuthenticationStateChanged(task);
            return task;
        }

        public Task<AuthenticationState> Logout()
        {
            this.CurrentUser = this.GetAnonymous();
            var task = this.GetAuthenticationStateAsync();
            this.NotifyAuthenticationStateChanged(task);
            return task;
        }
    }
}
