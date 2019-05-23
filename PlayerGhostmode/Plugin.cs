using Smod2.API;
using Smod2.Attributes;
using System;

namespace Ghostmode
{
	[PluginDetails(
	author = "Cyanox",
	name = "PlayerGhostmode",
	description = "Makes players invisible.",
	id = "cyan.playerghostmode",
	version = "1.0.0",
	SmodMajor = 3,
	SmodMinor = 0,
	SmodRevision = 0
	)]
	public class Plugin : Smod2.Plugin
	{
		private static Plugin instance;

		public override void OnDisable() { }

		public override void OnEnable() { }

		public override void Register()
		{
			instance = this;

			AddCommands(new[] { "gmhide" }, new HideCommand());
			AddCommands(new[] { "gmshow" }, new ShowCommand());
			AddCommands(new[] { "gmhideglobal" }, new HideGlobalCommand());
			AddCommands(new[] { "gmshowglobal" }, new ShowGlobalCommand());
		}

		private static int LevenshteinDistance(string s, string t)
		{
			int n = s.Length;
			int m = t.Length;
			int[,] d = new int[n + 1, m + 1];

			if (n == 0)
			{
				return m;
			}

			if (m == 0)
			{
				return n;
			}

			for (int i = 0; i <= n; d[i, 0] = i++)
			{
			}

			for (int j = 0; j <= m; d[0, j] = j++)
			{
			}

			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= m; j++)
				{
					int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

					d[i, j] = Math.Min(
						Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1),
						d[i - 1, j - 1] + cost);
				}
			}
			return d[n, m];
		}

		public static Player GetPlayer(string args, out Player playerOut)
		{
			int maxNameLength = 31, LastnameDifference = 31;
			Player plyer = null;
			string str1 = args.ToLower();
			foreach (Player pl in instance.Server.GetPlayers(str1))
			{
				if (!pl.Name.ToLower().Contains(args.ToLower())) { goto NoPlayer; }
				if (str1.Length < maxNameLength)
				{
					int x = maxNameLength - str1.Length;
					int y = maxNameLength - pl.Name.Length;
					string str2 = pl.Name;
					for (int i = 0; i < x; i++)
					{
						str1 += "z";
					}
					for (int i = 0; i < y; i++)
					{
						str2 += "z";
					}
					int nameDifference = LevenshteinDistance(str1, str2);
					if (nameDifference < LastnameDifference)
					{
						LastnameDifference = nameDifference;
						plyer = pl;
					}
				}
			NoPlayer:;
			}
			playerOut = plyer;
			return playerOut;
		}
	}
}
