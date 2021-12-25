using System;
using Mirror;
using UniRx;

namespace FR.Tools.Networks
{
    public class ObservableNetworkManager: NetworkManager
    {
        public IObservable<Unit> WhenStartServer => _onStartServer;
        private readonly Subject<Unit> _onStartServer = new Subject<Unit>();
        
        public IObservable<Unit> WhenStopServer => _onStopServer;
        private readonly Subject<Unit> _onStopServer = new Subject<Unit>();
        
        public override void OnStartServer() => _onStartServer.OnNext(Unit.Default);
        
        public override void OnStopServer() => _onStopServer.OnNext(Unit.Default);
    }
}