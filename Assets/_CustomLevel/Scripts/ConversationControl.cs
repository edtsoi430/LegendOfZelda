using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationControl : MonoBehaviour {

    public Text text;
    public ArrowKeyMovement player_arm;
    public Inventory player_inventory;
    public Player player;
    public GameObject panel;
    public GameObject iori;
    public AudioClip type_sound;

    private string start_game1 = "Good Choice!";
    private string start_game2 = "Ready..........Go!!!!!";

    private string conversation_00 = "You can choose 1 power-up from the following.";
    private string conversation_01 = "Press Q to gain 3 more hit points.";
    private string conversation_02 = "Press W to gain 3 more bombs.";
    private string conversation_03 = "Press E to gain 1 more weapon damage.";
    private string conversation_04 = "Your Choice is?(Q - +3 hp, W - +3 bombs, E + 1 W.D"; 
    //private string conversation_00 = "1.";
    //private string conversation_01 = "2.";
    //private string conversation_02 = "3.";
    //private string conversation_03 = "4.";
    //private string conversation_04 = "5.";


    private string conversation_10 = "I'm your mighty king Iori!";
    private string conversation_11 = "In order to win, you need to take me down!";

    private string conversation_20 = "Why I lost? Why?";
    private string conversation_21 = "I'll be back. See u later!";

    private string conversation_30 = "Come on! I'll win this time...";
    private string conversation_31 = "HAHAHAHA... See my new ability!";

    private string conversation_40 = "Can't Believe...";
    private string conversation_41 = "Ummmmm... You win :(:(:(:(:(:(!";

    private bool t0;
    private bool t1;
    private bool t2;
    private bool t3;
    private bool t4;
    private bool next;
    private int count_0 = 0;
    private IEnumerator coroutine;
    private string[] conversations0;

    private void Awake()
    {
        conversations0 = new string[] { conversation_00, conversation_01, conversation_02, conversation_03, conversation_04 };
        t0 = false;
        t1 = false;
        t2 = false;
        t3 = false;
        t4 = false;
        next = false;
    }

    private void Update()
    {
        if (count_0 == 5)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                player.full_health += 3;
                player.current_health += 3;
                player.health_text.text = "Health: " + player.current_health.ToString() + " / " + player.full_health.ToString();
                coroutine = StartGame();
                StartCoroutine(coroutine);
                count_0 = 0;
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                player_inventory.AddBombs(3);
                coroutine = StartGame();
                StartCoroutine(coroutine);
                count_0 = 0;
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                iori.GetComponent<MotionControl>().damaged++;
                coroutine = StartGame();
                StartCoroutine(coroutine);
                count_0 = 0;
            }
            t0 = false;
            next = false;
        }

        while (t0 && next && count_0 < 5)
        {
            text.text = "";
            coroutine = SetConversation(conversations0[count_0], 0.1f, true);
            StartCoroutine(coroutine);
            next = false;
        }

        if (t1 && next)
        {
            text.text = "Iori: ";
            coroutine = SetConversation(conversation_11, 0.1f, true);
            StartCoroutine(coroutine);
            next = false;
            t1 = false;
            Invoke("Text0", 7.5f);
        }

        if (t2 && next)
        {
            text.text = "Iori: ";
            coroutine = SetConversation(conversation_21, 0.1f, false);
            StartCoroutine(coroutine);
            next = false;
            t2 = false;
        }

        if (t3 && next)
        {
            text.text = "Iori: ";
            coroutine = SetConversation(conversation_31, 0.1f, true);
            StartCoroutine(coroutine);
            next = false;
            t3 = false;
            Invoke("Text0", 7.5f);
        }

        if (t4 && next)
        {
            text.text = "Iori: ";
            coroutine = SetConversation(conversation_41, 0.1f, false);
            StartCoroutine(coroutine);
            next = false;
            t4 = false;
        }
    }

    private void Text0()
    {
        t1 = false;
        t0 = true;
    }

    public void Text1()
    {
        next = false;
        t1 = true;
        panel.gameObject.SetActive(true);
        text.text = "Iori: ";
        coroutine = SetConversation(conversation_10, 0.1f, true);
        StartCoroutine(coroutine);
    }

    public void Text2()
    {
        next = false;
        t2 = true;
        panel.gameObject.SetActive(true);
        text.text = "Iori: ";
        coroutine = SetConversation(conversation_20, 0.1f, true);
        StartCoroutine(coroutine);
    }

    public void Text3()
    {
        next = false;
        t3 = true;
        panel.gameObject.SetActive(true);
        text.text = "Iori: ";
        coroutine = SetConversation(conversation_30, 0.1f, true);
        StartCoroutine(coroutine);
    }

    public void Text4()
    {
        next = false;
        t4 = true;
        panel.gameObject.SetActive(true);
        text.text = "Iori: ";
        coroutine = SetConversation(conversation_40, 0.1f, true);
        StartCoroutine(coroutine);
    }

    IEnumerator SetConversation(string con, float time, bool deact)
    {
        foreach (char c in con)
        {
            yield return new WaitForSeconds(time);
            text.text = text.text + c;
            AudioSource.PlayClipAtPoint(type_sound, Camera.main.transform.position);
        }
        yield return new WaitForSeconds(2);
        panel.gameObject.SetActive(deact);
        next = true;
        if (t0)
        {
            count_0++;
        }
    }

    IEnumerator StartGame()
    {
        text.text = "";
        foreach (char c in start_game1)
        {
            yield return new WaitForSeconds(0.1f);
            text.text = text.text + c;
        }
        yield return new WaitForSeconds(2);
        text.text = "";
        foreach (char c in start_game2)
        {
            yield return new WaitForSeconds(0.1f);
            text.text = text.text + c;
        }
        panel.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        iori.GetComponent<MotionControl>().trigger = true;
        iori.GetComponent<MotionControl>().GetBomb();
        player_arm.gold = false;
    }
}
