using Smod2.API;
using Smod2.Commands;
using TargetedGhostmode;

namespace Ghostmode
{
	class ShowCommand : ICommandHandler
	{
		public string GetCommandDescription()
		{
			return "Makes a player visible to another player.";
		}

		public string GetUsage()
		{
			return "GMSHOW (SOURCE) (TARGET)";
		}

		public string[] OnCall(ICommandSender sender, string[] args)
		{
			if (args.Length > 1)
			{
				Player source = Plugin.GetPlayer(args[0], out source);
				Player target = Plugin.GetPlayer(args[1], out target);
				if (source != null && target != null)
				{
					if (source.IsHiddenFrom(target))
					{
						source.ShowPlayer(target);
						return new string[] { $"Player {target.Name} is now visible to {source.Name}." };
					}
					else
					{
						return new string[] { $"Player {target.Name} is already visible to {source.Name}." };
					}
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
