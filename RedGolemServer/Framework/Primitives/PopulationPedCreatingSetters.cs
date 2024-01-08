using CitizenFX.Core;

namespace RedGolemServer.Framework.Primitives
{
    public class PopulationPedCreatingSetters
    {
        private readonly dynamic _setter;

        public PopulationPedCreatingSetters(ref dynamic setter)
        {
            _setter = setter;
        }

        public void SetModel(string model)
        {
            _setter.setModel(model);
        }

        public void SetPosition(Vector3 position)
        {
            _setter.setPosition(position);
        }
    }
}
