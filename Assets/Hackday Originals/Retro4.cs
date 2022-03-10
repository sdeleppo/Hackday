using System.Collections;
using System.Collections.Generic;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
//[RequireComponent(typeof(AnimationController), typeof(Collider2D))]
public class Retro4 : MonoBehaviour
{
    //public PatrolPath path;
        //public AudioClip fall;

        //internal PatrolPath.Mover mover;
        public Animation anim;
        public Collider2D _collider;
        internal bool collided;
        public float timer = 0;
        public bool timeReached = false;
        //internal AudioSource _audio;
        internal Rigidbody2D rigid;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            anim = gameObject.GetComponent<Animation>();
            _collider = GetComponent<Collider2D>();
            collided = false;
            rigid = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var player = collision.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                anim.Play("retro wobble");
                collided = true;
            }
        }

        void Update()
        {
            if (collided && !timeReached) 
            {
                timer += Time.deltaTime;
            }

            if (!timeReached && timer > 2) {
                anim.Play("Fall 4");
                //rigid.bodyType = RigidbodyType2D.Dynamic;
                timeReached = true;
            }
        }
    }
}
