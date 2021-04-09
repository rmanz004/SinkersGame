using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hearts = 3;
    public int maxHearts = 3;
    [SerializeField] HeartSystem heartSystem;

    private void Start(){
        heartSystem.DrawHeart(hearts,maxHearts);
    }
    public void DamagePlayer(int dmg){
        if(hearts > 0){
            hearts -= dmg;
            heartSystem.DrawHeart(hearts,maxHearts);
        }
    }

    public void HealPlayer(int heal){
        if(hearts < maxHearts){
            hearts += heal;
            heartSystem.DrawHeart(hearts,maxHearts);
        }
    }
}
