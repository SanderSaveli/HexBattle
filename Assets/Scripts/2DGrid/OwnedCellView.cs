using UnityEngine;
using Zenject;

namespace CellField2D
{
    public class OwnedCellView : MonoBehaviour
    {
        private IOwnedCell cell;
        private ThemeManager themeManager;
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetObservedCell(IOwnedCell cell)
        {
            this.cell = cell;
            cell.OnOwnerChanged += ChangeColor;
            ChangeColor(cell.ownerID);
        }

        public void ChangeColor(int ownerID)
        {
            Debug.Log(themeManager.GetPlayerColor(ownerID));
            spriteRenderer.color = themeManager.GetPlayerColor(ownerID);
        }

        [Inject]
        public void Construct(ThemeManager themeManager)
        {
            this.themeManager = themeManager;
        }
    }
}
