﻿#region Copyright & License Information
/*
 * Copyright 2007-2015 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation. For more information,
 * see COPYING.
 */
#endregion

using System.Linq;
using OpenRA.Mods.RA.Traits;
using OpenRA.Scripting;
using OpenRA.Traits;

namespace OpenRA.Mods.RA.Scripting
{
	[ScriptPropertyGroup("Ability")]
	public class DisguiseProperties : ScriptActorProperties, Requires<DisguiseInfo>
	{
		readonly Disguise disguise;

		public DisguiseProperties(ScriptContext context, Actor self)
			: base(context, self)
		{
			disguise = Self.Trait<Disguise>();
		}

		[Desc("Disguises as the target actor.")]
		public void DisguiseAs(Actor target)
		{
			disguise.DisguiseAs(target);
		}

		[Desc("Disguises as the target type with the specified owner.")]
		public void DisguiseAsType(string actorType, Player newOwner)
		{
			var actorInfo = Self.World.Map.Rules.Actors[actorType];
			disguise.DisguiseAs(actorInfo, newOwner);
		}
	}
}
