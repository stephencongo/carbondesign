using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace mnglabs.genomemanager.ui.services.Service
{
    public class StateContainer
    {
        private ConcurrentDictionary<Guid, int> _loginAttempts;

        public StateContainer()
        {
            _loginAttempts = new ConcurrentDictionary<Guid, int>();
        }
        public int GetLoginAttempts(Guid sessionId)
        {
            if(_loginAttempts.ContainsKey(sessionId)) 
            {
                return _loginAttempts[sessionId];
            }
            else
            {
                _loginAttempts.TryAdd(sessionId, 0);
                return 0;
            }
        }

        public void SetLoginAttempts(Guid sessionId, int loginAttempt)
        {
            if(_loginAttempts.ContainsKey(sessionId))
            {
                _loginAttempts[sessionId] = loginAttempt;
            }
            else
            {
                _loginAttempts.TryAdd(sessionId, loginAttempt);
            }

        }

        public event Action? OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
