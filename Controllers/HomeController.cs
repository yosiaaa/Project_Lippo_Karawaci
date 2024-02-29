using Microsoft.AspNetCore.Mvc;
using ProjectLippoKarawaci.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentAllocation.Controllers
{
    public class HomeController : Controller
    {
        // Data tagihan dari contoh Anda
        private List<Tagihan> tagihans = new List<Tagihan>
        {
            new Tagihan { Nomor = "1", DueDate = new DateTime(2023, 1, 10), Amount = 165000, RemainingAmount = 165000 },
            new Tagihan { Nomor = "2", DueDate = new DateTime(2023, 2, 15), Amount = 80000, RemainingAmount = 80000 },
            new Tagihan { Nomor = "3", DueDate = new DateTime(2023, 1, 20), Amount = 130000, RemainingAmount = 130000 },
            new Tagihan { Nomor = "4", DueDate = new DateTime(2023, 3, 25), Amount = 416000, RemainingAmount = 416000 },
            new Tagihan { Nomor = "5", DueDate = new DateTime(2023, 2, 10), Amount = 95500, RemainingAmount = 95500 },
            new Tagihan { Nomor = "6", DueDate = new DateTime(2023, 8, 17), Amount = 523000, RemainingAmount = 523000 }
        };

        public ActionResult Index()
        {
            return View();
        }

        // Action method untuk alokasi pembayaran
        [HttpPost]
        public ActionResult AllocatePayment(decimal payment)
        {
            if (payment <= 0)
            {
                ViewBag.Message = "Payment amount must be greater than zero.";
                return View("Index");
            }

            var remainingPayment = payment;

            foreach (var tagihan in tagihans.OrderBy(t => t.DueDate))
            {
                if (tagihan.RemainingAmount <= 0)
                    continue;

                if (remainingPayment >= tagihan.RemainingAmount)
                {
                    tagihan.RemainingAmount = 0;
                    remainingPayment -= tagihan.Amount;
                }
                else
                {
                    tagihan.RemainingAmount -= remainingPayment;
                    remainingPayment = 0;
                }

                if (remainingPayment <= 0)
                    break;
            }

            ViewBag.Tagihans = tagihans;
            return View("Index");
        }

        // Action method untuk query total undue dan overdue
        public ActionResult GetTotalDueStatus()
        {
            var currentDate = new DateTime(2023, 3, 25); // Tanggal hari ini
            var totalUndue = tagihans.Where(t => t.DueDate > currentDate).Sum(t => t.Amount);
            var totalOverdue = tagihans.Where(t => t.DueDate <= currentDate && t.RemainingAmount > 0).Sum(t => t.RemainingAmount);

            ViewBag.TotalUndue = totalUndue;
            ViewBag.TotalOverdue = totalOverdue;

            return View("TotalDueStatus");
        }
    }
}
