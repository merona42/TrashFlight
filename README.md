# TrashFlight

배경 움직임 - Script를 통해 아래로 이동시켜가며 특정위치가 되면 다시 위로 올라가게 하여 캐릭터가 위로 진행하는 느낌을 구현<br>
캐릭터 움직임 - 마우스의 position에 위치를 바꾸고 clamp함수를 통해 최소위치와 최대위치를 구현<br>
탄환 충돌 구현 - rigidBody2D와 Script를 통해 Tag가 Enemy면 Weapon의 Dmg만큼 Hp가 깎이도록 구현<br>
적 출현 - EnemySpawner객체를 만들고 코루틴을 통해 특정시간마다 enemy객체를 지정된 위치에서 생성하도록 구현<br>
코인 - 각 Enemy가 hp가 0 이되면 Destroy될때 coin객체를 Instantiate 함수를 통해 구현, RigidBody2D 컴포넌트를 추가해 중력이 적용되게 하고,<br>
rigidBody의 AddForce함수를 이용하여 포물선을 그리며 떨어지도록 함.<br>
무기 업그레이드 - GameManager객체를 통해 코인을 얻을때 특정 코인 이상이 되면 player 객체에 생성되는 weapon객체를 변경시켜 업그레이드를 구현함.<br>
플레이어가 적과 닿거나 Boss처리시 게임오버 panel이 setActive(true)가 되게끔함.<br>
<hr/>
<b>[게임설명]</b><br>
플레이어를 마우스로 움직이며 하늘에서 주기적으로 내려오는 적들을 처치해가며 코인을 획득한다.<br>
일정 코인 이상을 먹으면 자동으로 무기가 업그레이드 되고, 최종적으로 보스를 처치 한 후 게임이 종료되었을 때, 얻었던 코인의 갯수가 최종 점수가 된다.<br>
