// ######################################################################
// ITransformProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public interface ITransformProvider
	{
		Transform Transform { get; }
	}
}