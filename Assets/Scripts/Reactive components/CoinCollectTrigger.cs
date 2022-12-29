using UnityEngine;

namespace Domain.Interactions.Triggered
{
    public class CoinCollectTrigger : ReactiveComponent
    {
        [SerializeField] private string _tag;

        public override void OnEnter(GameObject anObject)
        {
            if( anObject.CompareTag(_tag) )
            {
                Collect();
                SelfDestroy();
            }
        }

        public override void OnExit(GameObject anObject) { }

        public override void OnStay(GameObject anObject) { }

        private void Collect()
        {
            int coins = PlayerPrefs.GetInt("coins");
            
            PlayerPrefs.SetInt("coins", coins + 1 );
        }

        private void SelfDestroy()
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
