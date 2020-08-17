using System.Collections;
using System.Collections.Generic;

using TelegramBot.AspNetCore.Models.Commands;

namespace TelegramBot.AspNetCore.Models {
    internal class CommandsList : IEnumerable<Command> {

        private IList<Command> _commands = new List<Command>();

        public IEnumerator<Command> GetEnumerator()
        {
            return _commands.GetEnumerator();
        }

        internal void Add(Command command)
        {
            _commands.Add(command);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
