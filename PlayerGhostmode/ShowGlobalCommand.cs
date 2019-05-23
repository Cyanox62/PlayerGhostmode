using Smod2.API;
using Smod2.Commands;
using TargetedGhostmode;

namespace Ghostmode
{
	class ShowGlobalCommand : ICommandHandler
	{
		public string GetCommandDescription()
		{
			return "Makes a player visible to all players.";
		}

		public string GetUsage()
		{
			return "GMSHOWGLOBAL (TARGET)";
		}

		public string[] OnCall(ICommandSender sender, string[] args)
		{
			if (args.Length > 0)
			{
				Player target = Plugin.GetPlayer(args[0], out target);
				if (target != null)
				{
					target.ShowGlobal();
					return new string[] { $"Player {target.Name} is now visible to everyone." };
				}
				else
				{
					return new string[] { "Invalid player." };
				}
			}
			else
			{
				return new string[] { GetUsage() };
			}
		}
	}
}
