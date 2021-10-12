using Solcery.UI.Wallet;
using Solcery.Utils;

namespace Solcery.Modules
{
    public class Wallet : Singleton<Wallet>
    {
        public WalletConnection Connection => _connection;
        private WalletConnection _connection;

        public void Init()
        {
            _connection = new WalletConnection();
            UIWallet.Instance?.Init(this);
        }

        public void DeInit()
        {
            UIWallet.Instance?.DeInit();
        }
    }
}