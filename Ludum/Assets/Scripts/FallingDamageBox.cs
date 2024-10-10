using UnityEngine;

public class FallingDamageBox : MonoBehaviour
{
    public float fallSpeed = 2f;
    public float lifespan = 5f; // Время жизни коробки
    public float damageBoostDuration = 5f; // Длительность увеличения урона

    private void Start()
    {
        Destroy(gameObject, lifespan); // Уничтожаем коробку через заданное время
    }

    private void OnMouseDown() // Вызывается при клике на коробку
    {
        DestroyBox(); // Уничтожаем коробку
    }

    private void DestroyBox()
    {
        PlayerClick playerClick = FindObjectOfType<PlayerClick>();
        if (playerClick != null)
        {
            playerClick.ActivateDamageBoost(damageBoostDuration); // Активируем увеличение урона
        }

        // Здесь можно добавить эффекты разрушения, например, звук или анимацию
        Destroy(gameObject); // Уничтожаем коробку
    }
}