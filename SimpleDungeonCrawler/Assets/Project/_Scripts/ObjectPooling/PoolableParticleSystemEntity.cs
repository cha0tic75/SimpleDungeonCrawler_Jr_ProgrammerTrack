// ######################################################################
// PoolableParticleSystemEntity - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.ObjectPooling
{
    public class PoolableParticleSystemEntity : PoolableEntity
	{
        #region MonoBehaviour Callback Method(s):
		private void OnParticleSystemStopped() => ReturnToObjectPool();
        #endregion
	}
}
