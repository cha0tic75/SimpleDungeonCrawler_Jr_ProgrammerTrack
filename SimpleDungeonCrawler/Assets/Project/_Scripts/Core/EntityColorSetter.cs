// ######################################################################
// EntityColorSetter - Script description goes here
//
// Written by Tim McCune <tim.mccune1975@gmail.com>
// ######################################################################

using UnityEngine;

namespace Project
{
    public class EntityColorSetter : MonoBehaviour
    {
        #region Inspector Assigned Field(s):
        [SerializeField] private Color m_color = new Color(1f, 1f, 1f, 1f);
        [SerializeField] private Items.Item_SO m_item = null;
        [SerializeField] private bool m_overrideItemColor = false;
        [SerializeField] private SpriteRenderer m_spriteRenderer;
        [SerializeField] private UnityEngine.Rendering.Universal.Light2D m_light;
        [SerializeField, Range(0f, 1f)] private float m_lightAlpha = 0.3f;
        #endregion

        #region MonoBehaviour(s):
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (m_item != null && !m_overrideItemColor) { m_color = m_item.ItemVisuals.Color; }
            SetColors();
        }
#endif
        private void Start()
        {
            SetColors();
            Destroy(this);
        }
        #endregion

        #region Internally Used Method(s):
        private void SetColors()
        {
            if (m_spriteRenderer != null)
            {
                m_spriteRenderer.color = m_color;
            }

            if (m_light != null)
            {
                Color lightColor = new Color(m_color.r, m_color.g, m_color.b, m_lightAlpha);
                m_light.color = lightColor;
            }
        }
        #endregion
    }
}