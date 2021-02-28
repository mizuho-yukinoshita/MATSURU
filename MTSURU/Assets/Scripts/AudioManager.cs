using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // AudioCLip : 音声データ
    public AudioClip[] audio_clips;
    // 音声を再生するためのメソッド(同時に再生開始しても切れないよう複数用意)
    public AudioSource[] audio_source;

    private static AudioManager _object = null;
    public static AudioManager Object => _object;

    // enum SoundList : マジックナンバーをなくすための変数
    public enum SoundList
    {
        // MUSIC : このシーンのBGM
        MUSIC = 0,
        // SE_START : ゲーム開始のSE
        SE_START,
        // SE_RIGHT : 正しいキーが押されたときのSE
        SE_RIGHT,
        // SE_WRONG : キーが間違っていたときのSE
        SE_WRONG,
        // SE_COMPLETE : 絹織物が1枚完成した時のSE
        SE_COMPLETE,
        // SE_FINISH : ゲーム終了のSE
        SE_FINISH,
    }

    private void Awake()
    {
        _object = this;
        // インスペクタで指定された音声をAudioSourceに登録
        for (int i = 0; i < 6; i++)
        {
            audio_source[i].clip = audio_clips[i];
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(SoundList list)
    {
        Object.audio_source[(int)list].Play();
    }

}
