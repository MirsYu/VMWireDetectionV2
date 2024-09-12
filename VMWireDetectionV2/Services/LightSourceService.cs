using System;

namespace VMWireDetectionV2.Services
{
    public interface ILightSourceService
    {
        void TurnOn();
        void TurnOff();
        void SetLigthValue();
        bool IsOn { get; }
    }

    public class LightSourceService : ILightSourceService
    {
        public bool IsOn => throw new NotImplementedException();

        public void SetLigthValue()
        {
            throw new NotImplementedException();
        }

        public void TurnOff()
        {
            throw new NotImplementedException();
        }

        public void TurnOn()
        {
            throw new NotImplementedException();
        }
    }
}
