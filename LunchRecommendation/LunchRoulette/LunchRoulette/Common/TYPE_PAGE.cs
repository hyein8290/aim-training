using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchRoulette.Common
{
    public enum TYPE_PAGE
    {
        LOGIN_PAGE = 0,     // 로그인 페이지 
        JOIN_PAGE = 1,      // 회원 가입 페이지 
        MENU_PAGE = 2,      // 메뉴 페이지
        REST_LIST_PAGE = 3,      // 식당목록 페이지
        REST_ADD_PAGE = 4,  // 식당 추가 페이지
        REST_EDIT_PAGE = 5, // 식당 편집 페이지
        ROULETTE_PAGE = 6,  // 식당 추천 페이지
        PICK_PAGE = 7,      // 식당 선택 페이지
        __MAX__
    }
}
