using System.Collections;
using UnityEngine;

namespace AntonSiadun.StickyWallsProto.Domain.Interactions.Active
{
    public class ElectricModificator : MonoBehaviour
    {
        [SerializeField] private float _cooldown;
        [SerializeField] private GameObject _lightningDischarge;
        [SerializeField] private GameObject _fixedWall;

        private void Start()
        {
            HideDischarge();

            StartCoroutine(GeneratePulseOccasionally());    
        }

        public IEnumerator GeneratePulseOccasionally()
        {
            if (_cooldown <= 0)
                throw new System.ArgumentException("Cooldown must be a positive value.");

            for(; ; )
            {
                yield return new WaitForSeconds(_cooldown);
                yield return ShowPulse();
            }
        }

        protected IEnumerator ShowPulse()
        {
            if (_lightningDischarge == null)
                throw new System.NullReferenceException("Can't find a lightning discharge object.");

            ShowDischarge();

            yield return new WaitForSeconds(0.5f);

            HideDischarge();
        }

        private void ShowDischarge()
        {
            Debug.Log("Electric modificator on object:" + gameObject.name +
                    " showed discharge");
            _fixedWall.SetActive(false);
            _lightningDischarge.SetActive(true);
        }

        private void HideDischarge()
        {
            Debug.Log("Electric modificator on object:" + gameObject.name +
                    " hided discharge");
            _fixedWall.SetActive(true);
            _lightningDischarge.SetActive(false);
        }
    }
}