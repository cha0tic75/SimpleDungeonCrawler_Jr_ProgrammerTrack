// ######################################################################
// IInteractorDataProvider - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

namespace Project.Interaction
{
    public interface IInteractorDataProvider : IHandlerDataProvider { }

    public interface IDamagableDataProvider : IHandlerDataProvider
    {
        Actors.Stats.IDamagable Damagable { get; }
    }
}