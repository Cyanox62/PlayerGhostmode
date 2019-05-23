using Smod2.API;
using Smod2.Commands;
using TargetedGhostmode;

namespace Ghostmode
{
	class HideGlobalCommand : ICommandHandler
	{
		public string GetCommandDescription()
		{
			return "Hides a player from all players.";
		}

		public string GetUsage()
		{
			return "GMHIDEGLOBAL (TARGET)";
		}

		public string[] OnCall(ICommandSender sender, string[] args)
		{
			if (args.Length > 0)
			{
				Player target = Plugin.GetPlayer(args[0], out target);
				if (target != null)
				{
					target.HideGlobal();
					return new string[] { $"Player {target.Name} is now hidden from everyone." };
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
