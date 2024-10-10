using UnityEngine;

public class FallingFreezeBox : MonoBehaviour
{
    public float fallSpeed = 2f; // Скорость падения
    public float lifespan = 5f; // Время жизни коробки
    public EnemyFreeze[] enemiesToFreeze; // Массив врагов, которых нужно заморозить
    public float freezeDuration = 5f; // Длительность заморозки

    private void Start()
    {
        Destroy(gameObject, lifespan); // Уничтожаем коробку через заданное время
    }

    private void Update()
    {
        // Двигаем коробку вниз
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private void OnMouseDown() // Вызывается при клике на коробку
    {
        DestroyBox(); // Уничтожаем коробку
    }

    private void DestroyBox()
    {
        // Замораживаем врагов
        foreach (var enemy in enemiesToFreeze)
        {
            if (enemy != null)
            {
                enemy.Freeze(freezeDuration); // Замораживаем врага
            }
        }

        // Здесь можно добавить эффекты разрушения, например, звук или анимацию
        Destroy(gameObject); // Уничтожаем коробку
    }
}
