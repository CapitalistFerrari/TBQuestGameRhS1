using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBQuestGameRH.Models;

namespace TBQuestGameRH.PresentationLayer
{
    class GameSessionViewModel
    {
        #region FIELDS 

        private Player _player;
        private List<string> _messages;

        #endregion

        #region PROPERTIES

        public Player Player
        {
            get { return _player;  }
            set { _player = value; }
        }

        //
        // Return the list of strings converted to a single string
        // with the new lines between each message
        //

        public string MessageDisplay
        {
            get { return string.Join("\n\n", _messages);  }
        }

        #endregion

        #region CONSTRCUTORS

        public GameSessionViewModel()
        {

        }

        public GameSessionViewModel(Player player, List<string> initialMessages)
        {
            _player = player;
            _messages = initialMessages;
        }

        #endregion
    }
}
